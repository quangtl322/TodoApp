import React, { Component } from 'react'
import { connect } from 'react-redux';
import {
    Button,
    Input,
    Form,
    FormGroup,
    Label,
    Table
} from 'reactstrap';
import * as actions from './../redux/actions/';
import axios from 'axios';
class Dashboard extends Component {
    constructor(props) {
        super(props)
        this.state = {
            username: "",
            password: "",
            code: "",
            requestId: ""
        }
    }

    nameRef = React.createRef().value;
    onAdd = async (event) => {
        event.preventDefault();
        console.log(this.state)
        let data = Object.assign({}, { username: this.state.username, password: this.state.password })
        //  this.props.onAdd({ ...this.state });
        await axios({
            method: 'post',
            url: 'https://localhost:44373/api/employee',
            data: data,
            headers: {
                accept: "application/json",
                contentType: "application/json",
            }
        }).then(data => {
            console.log(data)
            this.setState({
                requestId: data.data
            })
        }).catch(err => {
            console.log(err.response);
        });
        this.onGetData();
        this.setState({
            username: '',
            password: ''
        })
    }

    onVerify = async (event) => {
        event.preventDefault();
        let { code, requestId } = this.state;
        let data = {
            code,
            requestId
        }
        console.log(data);
        await axios({
            method: 'post',
            url: 'https://localhost:44373/api/employee/verify',
            data: data,
            headers: {
                accept: "application/json",
                contentType: "application/json",
            }
        }).then(data => {
            console.log(data)
        }).catch(err => {
            console.log(err.response);
        });
    }

    onChange = (event) => {
        var target = event.target;
        var name = target.name;
        var value = target.type === 'checkbox' ? target.checked : target.value;
        this.setState({
            [name]: value
        })
    }
    onGetData = () => {
        let params = {
            offset: 1,
            limit: 10,
            query: '',
            sortName: '',
            isDesc: false
        }
        this.props.onGetData(params)
    }
    componentDidMount() {
        this.onGetData();
    }
    render() {
        const { employees } = this.props.employees;
        var result = employees ? employees.map((item, index) => {
            return (
                <tr key={index}>
                    <td >{item.username}</td>
                    <td >{item.password}</td>
                </tr>
            )
        }) : null;


        return (
            <div className="dashboard">
                <p>Dashboard Component</p>
                <Button color="primary" onClick={this.onGetData}>Get Data</Button>

                <Table bordered>
                    <thead>
                        <tr>
                            <th>Username</th>
                            <th>Password</th>
                        </tr>
                    </thead>
                    <tbody>
                        {result}
                    </tbody>
                </Table>

                <Form onSubmit={this.onAdd}>
                    <FormGroup>
                        <Label for="exampleEmail">Username</Label>
                        <Input type="text" placeholder="with a placeholder"
                            name="username"
                            value={this.state.username}
                            onChange={this.onChange}
                        />
                    </FormGroup>
                    <FormGroup>
                        <Label for="examplePassword">Password</Label>
                        <Input type="password" id="examplePassword" placeholder="password placeholder"
                            name="password"
                            onChange={this.onChange}
                            value={this.state.password}
                        />
                    </FormGroup>
                    <Button color="primary" type="submit">Add</Button>

                </Form>

                <Form onSubmit={this.onVerify}>
                    <FormGroup>
                        <Label for="examplePassword">Code</Label>
                        <Input type="text"
                            name="code"
                            onChange={this.onChange}
                        />
                    </FormGroup>
                    <Button color="primary" type="submit">Verify</Button>

                </Form>
                {/* <Input name="item" innerRef={input => (this.nameRef = input)} /> */}
            </div>
        )
    }
}
const mapStateToProps = (state) => {
    return {
        employees: state.employees
    }
}
const mapDispatchToProps = (dispatch) => {
    return {
        onGetData: (params) => dispatch(actions.getEmployee(params))
    }
}
export default connect(mapStateToProps, mapDispatchToProps)(Dashboard)
