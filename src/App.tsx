import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import SignUp from "./Components/SignUp";
import Login from "./Components/Login";
import PrivateRoute from "./Auth/PrivateRoute";
import Home from "./Components/Home";
import RestrictedRoute from "./Auth/RestrictedRoute";
import {BrowserRouter, Route, Switch} from 'react-router-dom';
function App() {
  return (
      <BrowserRouter>
      <Switch>
        <PrivateRoute exact path="/" component={Home}/>
        <RestrictedRoute exact path="/login" component={Login} />
        <Route path="/register"><SignUp /></Route>
        </Switch>
    </BrowserRouter>
  );
}

export default App;
