import React, { Component } from 'react'
import * as signalR from '@aspnet/signalr';
export default class Profile extends Component {

    constructor(props) {
        super(props);
        this.connection = null;
    }

    send = async () => {
        let message = "anh yeu em";
        this.connection.invoke("SendMessage", message)
            .catch(err => console.error(err.toString()));
    }

    componentDidMount = () => {
        //    const protocol = new signalR.JsonHubProtocol();

        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:44373/chat")
            //  .withHubProtocol(protocol)
            .build();

        this.connection.start()
            .then(() => console.log('SignalR Connected'))
            .catch(err => console.log('SignalR Connection Error: ', err));

        this.connection.on("ReceiveMessage", data => {
            console.log(data);
        });
    }
    render() {
        console.log("render")
        return (
            <div className="profile">
                Profile
                <button onClick={this.send}>send</button>
            </div>
        )
    }
}
