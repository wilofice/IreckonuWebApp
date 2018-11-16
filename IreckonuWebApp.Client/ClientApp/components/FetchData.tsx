import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchOrdersDataState {
    orders: Order[];
    loading: boolean;
}



export class FetchData extends React.Component<RouteComponentProps<{}>, FetchOrdersDataState> {

    private filesContent: string[] = [];
    private endpoint: string = "http://localhost:8892/api/v1/Orders";
    constructor() {
        super();
        this.state = { orders: [], loading: true};
        this.handleChange = this.handleChange.bind(this);

        fetch(this.endpoint).then(response => response.json() as Promise<Order[]>)
            .then(data => {
                this.setState({ orders: data, loading: false});
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderForecastsTable(this.state.orders);

        return <div>
            <h1>Orders</h1>
            <div>
                <input type="file" className="form-control btn btn-primary" accept=".csv" multiple onChange={(e) => this.handleChange(e)}/>
            </div>
            <h2>List of elements in the data-store</h2>
            { contents }
        </div>;
    }

    handleChange(e: React.ChangeEvent<HTMLInputElement>) {
        e.preventDefault();
        let files : FileList = e.target.files !== null? e.target.files : new FileList();
        for (var i = 0; i < files.length; i++){
            if (files == null) return;
            const file = files[i];
            const reader = new FileReader();
            reader.onloadend = () => {
                console.log(reader.result)
                const content: string = reader.result; 
                fetch(this.endpoint, {
                    method: 'POST',
                    headers: {
                        'Accept': 'application/json',  
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        filesContent: [content]
                    })
                }).then(response => { });
                if (i >= files.length - 1) {
                    window.location.reload();
                }
            }
            reader.readAsText(file);
        }
        
    }

    private static renderForecastsTable(orders: Order[]) {
        const rows = orders.map(function (order: Order, index : number) {
            return <tr key={order.id}>
                <td>{index+1}</td>
                <td>{order.key}</td>
                <td>{order.artikelCode}</td>
                <td>{order.colorCode}</td>
                <td>{order.desciption}</td>
                <td>{order.price}</td>
                <td>{order.discountPrice}</td>
                <td>{order.q1}</td>
                <td>{order.size}</td>
                <td>{order.color}</td>
            </tr>});
        return <table className='table table-bordered'>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Key</th>
                    <th>ArtikelCode</th>
                    <th>ColorCode</th>
                    <th>Desciption</th>
                    <th>Price</th>
                    <th>DiscountPrice</th>
                    <th>Q1</th>
                    <th>Size</th>
                    <th>Color</th>
                </tr>
            </thead>
            <tbody>
                {rows}
            </tbody>
        </table>;
    }
}

export interface Order {
    id: string;
    key: string;
    artikelCode: string;
    colorCode: string;
    desciption: string;
    price:number;
    discountPrice:number;
    deliveredIn: string;
    q1: string;
    size: string;
    color: string;
    timestamp:string;
}
