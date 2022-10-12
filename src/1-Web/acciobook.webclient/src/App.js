import React, { Component } from 'react'; dist / css / bootstrap.min.css;

import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap'; 


export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    componentDidMount() {
        
    }

    render() {
        return (

            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>CAROLINE EU TE AMO!!!</p>               
            </div>
        );
    }
}
