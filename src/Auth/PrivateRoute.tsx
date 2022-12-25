
import { Redirect, Route } from "react-router-dom";

const PrivateRoute = (props:any) => {
  
  const token = localStorage.getItem("auth");
  
  return <>{token ? <Route {...props} /> : <Redirect to="/login" />}  </>;
  
};

export default PrivateRoute;