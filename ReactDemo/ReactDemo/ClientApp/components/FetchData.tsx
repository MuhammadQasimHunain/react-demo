import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchDataExampleState {
    datamodel: DataLayout[];
    loading: boolean;

}

export class FetchData extends React.Component<RouteComponentProps<{}>, FetchDataExampleState> {
    constructor() {
        super();
        this.state = { datamodel: [], loading: true, };
        fetch('api/SampleData/GetCompaniesData')
            .then(response => response.json() as Promise<DataLayout[]>)
            .then(data => {
                this.setState({ datamodel: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderdatamodelTable(this.state.datamodel);

        return <div>
            <h1>Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>;
    }
    private static handleClick = () => {
        debugger;
        console.log('this is clicked:');
    }
    private static renderdatamodelTable(datamodel: DataLayout[]) {

        return <table className='table'>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Count</th>
                    <th>Companies</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {
                    datamodel.map(model =>
                        <tr key={model.id}>
                            <td>{model.name}</td>
                            <td>{model.count}</td>
                            <td><span className="btn btn-primary"> Show List</span> </td>
                            <td>
                                <div className={`${model.id}`}>
                                    <ul>
                                        {
                                            model.customers.map(sub => <li >{sub.companyName}</li>)
                                        }
                                    </ul>
                                </div>
                            </td>
                        </tr>
                    )}
            </tbody>
        </table>;
    }
}

interface DataLayout {
    id: number;
    name: string;
    count: number;
    customers: Customer[];
}

interface Customer {
    id: number;
    customerId: string;
    address: string;
    city: string;
    companyName: string;
    email: string;
    firstname: string;
    postalCode: string;
    state: string;
    surname: string;
}