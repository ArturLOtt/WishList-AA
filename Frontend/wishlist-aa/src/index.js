import React from 'react';
import ReactDOM from 'react-dom';
import './pages/components/Login/App.css';
import * as serviceWorker from './serviceWorker';

import { Route, BrowserRouter as Router, Switch, Redirect } from "react-router-dom";
import "./index.css";
import App from "./pages/components/Login/App";
import Signin from "./pages/components/Signin/Signin";
import NotFound from "./pages/components/NotFound/Notfound";
import Listar from './pages/components/Listar/Listar';
import ListarporUser from './pages/components/ListarPorUser/Listar';

import {usuarioAutenticado} from "./services/auth";

const Permissao = ( {component : Component} ) => (
  <Route
    render = {props => usuarioAutenticado() ? 
      (<Component {...props} /> ) :
      (<Redirect to={{ pathname : "/listar" }} />)
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={App} />
        <Permissao  path="/listar" component={Listar} />
        <Permissao  path="/listarporuser" component={ListarporUser} />
        <Route path="/signin" component={Signin} />
        <Route component={NotFound}/>    
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(routing, document.getElementById("root"));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
