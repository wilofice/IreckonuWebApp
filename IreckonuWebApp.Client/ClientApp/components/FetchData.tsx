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
                <input type="file"  multiple onChange={(e) => this.handleChange(e)}/>
            </div>;
            <p>List of orders in the data-store</p>
            { contents }
        </div>;
    }

    handleChange(e: React.ChangeEvent<HTMLInputElement>) {
        e.preventDefault();
        console.log("handleChange")
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
                        filesContent: content
                    })
                }).then(response => { console.log("post response " + response + " " + content); });
            }
            reader.readAsText(file);
        }
        console.log("endfor");
        //this.forceUpdate()
        
    }

    private static renderForecastsTable(orders: Order[]) {
        orders.map(order => console.log("hllhl " + order.ArtikelCode));
        const rows = orders.map(function (order:Order) {
            return <tr key={order.Id}>
                <td>1{order.Key}</td>
                <td>2{order.ArtikelCode}</td>
                <td>3{order.ColorCode}</td>
                <td>4{order.Desciption}</td>
                <td>5{order.Price}</td>
                <td>6{order.DiscountPrice}</td>
                <td>7{order.Q1}</td>
                <td>8{order.Size}</td>
                <td>9{order.Color}</td>
            </tr>});
        return <table className='table'>
            <thead>
                <tr>
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

interface Order {
    Id: string;
    Key: string;
    ArtikelCode: string;
    ColorCode: string;
    Desciption: string;
    Price:number;
    DiscountPrice:number;
    DeliveredIn: string;
    Q1: string;
    Size: string;
    Color: string;
    Timestamp:string;
}
