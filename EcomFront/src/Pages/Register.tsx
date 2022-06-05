import React, {SyntheticEvent, useState } from 'react';
import {Navigate} from 'react-router-dom';

const Register = () => {
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [passwordconfirmation, SetPasswordConfirmation] = useState('');
    const [navigate, SetNavigate] = useState(false)

    const submit = async (e: SyntheticEvent) => {
        e.preventDefault();
     const response = await fetch("https://localhost:7019/api/user", {
         method: "POST",
         headers: {'Content-Type': "application/json"},
         mode: "cors",
         body: JSON.stringify({
             name,
             email,
             password,
             passwordconfirmation
         })
     });



        const content = await response.json();

     console.log(content)

        SetNavigate(true);
    }

    if(navigate) {
        return <Navigate to="/login"/>;
    }

    // @ts-ignore
    return (
            <form onSubmit={submit}>
            <img className="mb-4" src="/docs/5.1/assets/brand/bootstrap-logo.svg" alt="" width="72" height="57"/>
            <h1 className="h3 mb-3 fw-normal">Please Register</h1>
            <div className="form-floating">
                <input type="name" className="form-control" id="floatingInput" placeholder="name" required
                       onChange = {e => setName(e.target.value)}
                />
                <label htmlFor="floatingInput">Name</label>
            </div>
            <div className="form-floating">
                <input type="email" className="form-control" id="floatingInputE" placeholder="name@example.com"
                       onChange = {e => setEmail(e.target.value)}
                />
                <label htmlFor="floatingInput">Email address</label>
            </div>

            <div className="form-floating">
                <input type="password" className="form-control" id="floatingPassword" placeholder="Password"
                       onChange = {e => setPassword(e.target.value)}
                />
                <label htmlFor="floatingPassword">Password</label>

            </div>

                <div className="form-floating">
                    <input type="passwordconfirmation" className="form-control" id="floatingPassword" placeholder="Password"
                           onChange = {e => SetPasswordConfirmation(e.target.value)}
                    />
                    <label htmlFor="floatingPassword">Password Confirmation</label>

                </div>


            <button className="w-100 btn btn-lg btn-primary" type="submit">Submit</button>

        </form>

    );
};

export default Register;