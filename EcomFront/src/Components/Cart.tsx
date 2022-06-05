import React from 'react';
import {useSelector, useDispatch} from "react-redux";
import {delCart} from "../Redux/Action/index.js";

const Cart = () => {
    const state = useSelector((state: any)=> state.addItem)
    const dispatch = useDispatch();

    const handleClose = (item : any) => {
        dispatch(delCart(item))
    }

    const cartItems = (cartItem : any) => {
        return (
            <div className="px-4 my-5 bg-light rounded-3" key={cartItem.id}>
                <div className="container py-4">
                    <button onClick={() => handleClose(cartItem)} className="btn-close float-end"
                            aria-label="Close"></button>
                    <div className="row justify-content-center">
                        <div className="col-md-4">
                            <img src={cartItem.img} alt={cartItem.title} height="200px" width="180px"/>
                        </div>
                        <div className="col-md-4">
                            <h3>{cartItem.title}</h3>
                            <p className="lead fw-bold">${cartItem.price}</p>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
        return state.map(cartItems)
}

export default Cart;