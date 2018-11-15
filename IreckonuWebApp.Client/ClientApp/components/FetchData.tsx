import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchOrdersDataState {
    orders: Order[];
    loading: boolean;
}



export class FetchData extends React.Component<RouteComponentProps<{}>, FetchOrdersDataState> {

    private filesContent: string[] = [];

    constructor() {
        super();
        this.state = { orders: [], loading: true};
        this.handleChange = this.handleChange.bind(this);

        fetch('http://localhost:8892/api/Orders', {
            mode: "no-cors"
        }).then(response => response.json() as Promise<Order[]>)
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
        let files = e.target.files;
        if (files == null) return;
        for (var i = 0; i < files.length; i++) {
            let reader = new FileReader();
            reader.onloadend = () => {
                this.filesContent.push(reader.result);
            }
            reader.readAsText(files[i]);
            while (reader.readyState != reader.DONE);
        }
        console.log(this.filesContent)

        fetch('http://localhost:8892/api/Orders', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                filesContent: this.filesContent
            }),
            mode: "no-cors"
        })
        //this.forceUpdate()
        
    }

    private static renderForecastsTable(orders: Order[]) {
        orders.map(order => console.log("hllhl " + order.ArtikelCode));
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
            {orders.map(order =>
                <tr key={order.Id}>
                    <td>{order.Key}</td>
                    <td>{order.ArtikelCode}</td>
                    <td>{order.ColorCode}</td>
                    <td>{order.Desciption}</td>
                    <td>{order.Price}</td>
                    <td>{order.DiscountPrice}</td>
                    <td>{order.Q1}</td>
                    <td>{order.Size}</td>
                    <td>{order.Color}</td>
                </tr>
            )}
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
