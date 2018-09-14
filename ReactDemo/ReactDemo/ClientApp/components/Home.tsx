import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchDataExampleState {
    datamodel: DataLayout[];
    loading: boolean;

}

export class Home extends React.Component<RouteComponentProps<{}>, FetchDataExampleState> {
    constructor() {
        super();
        this.state = { datamodel: [], loading: true, };
        Home.handleClick = Home.handleClick.bind(this);
        fetch('api/SampleData/GetCompaniesData')
            .then(response => response.json() as Promise<DataLayout[]>)
            .then(data => {
                this.setState({ datamodel: data, loading: false });
            });

    }
    //this function render and return view
    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Home.renderdatamodelTable(this.state.datamodel);

        return <div>
            <h1>Companies count</h1>
            <p>This component demonstrates fetching data from the server.</p>
            <p>Companies list with coresponding companies </p>
            {contents}
        </div>;
    }
    private static handleClick() {
        console.log("Event is fierd.")
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
                            <td>
                                <div className={`${model.id}`}>
                                    <ul>
                                        {
                                            model.companies.map(sub => <li >{sub}</li>)
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
    companies: string[];
}
