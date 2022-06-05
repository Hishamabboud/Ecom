import React, {SyntheticEvent, useState} from "react";
import {Navigate} from "react-router-dom";
import Products from "../Components/Products";

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [refreshtoken, setRefreshtoken] = useState('');
    const [navigate, SetNavigate] = useState(false);
    const [authenticated, Setauthenticated] = useState(false);
    const [notauthenticated, Setnotauthenticated] = useState(true);

    const submit = async (e: SyntheticEvent) => {
        e.preventDefault();

        const responseL = await fetch("https://localhost:7019/api/Auth", {
            method: "POST",
            headers: {'Content-Type': "application/json"},
            credentials: 'include',
            mode: "cors",
            body: JSON.stringify({
                email,
                password,
                refreshtoken
            })

        });
        

        const contentL = await responseL.json();
        Setauthenticated(contentL.authenticated);
        if(contentL.authenticated == false)
        {
            alert("Wrong Email or Password")
        }
        SetNavigate(true);

    }

    if(authenticated == true)
    {
        return<Navigate to="/"/>;
    }


    return(
    <form onSubmit={submit}>
        <img className="mb-4" src="/docs/5.1/assets/brand/bootstrap-logo.svg" alt="" width="72" height="57"/>
        <h1 className="h3 mb-3 fw-normal">Please sign in</h1>

        <div className="form-floating">
            <input type="email" className="form-control" id="floatingInput" placeholder="name@example.com"
                onChange = {e => setEmail(e.target.value)}/>
            <label htmlFor="floatingInput">Email address</label>
        </div>
        <div className="form-floating">
            <input type="password" className="form-control" id="floatingPassword" placeholder="Password"
                   onChange = {e => setPassword(e.target.value)}/>
            <label htmlFor="floatingPassword">Password</label>
        </div>


        <button className="w-100 btn btn-lg btn-primary" type="submit">Sign in</button>

    </form>
);
};
export default Login;