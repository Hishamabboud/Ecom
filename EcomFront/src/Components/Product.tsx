import React, {useState, useEffect} from "react";
import {NavLink} from 'react-router-dom';
import {useParams} from 'react-router';
import {addCart} from "../Redux/Action";
import {Simulate} from "react-dom/test-utils";
import {useSelector, useDispatch} from "react-redux";
import Skeleton from "react-loading-skeleton";

const Product = () => {

    const {id} = useParams();
    const [product, setProduct] = useState([] as any);
    const[loading,setLoading] = useState(false);

    const dispatch = useDispatch();
    const addProduct = (product: any) =>
    {
        dispatch(addCart(product));
    }
    useEffect(() => {
        const getProduct = async () => {
            setLoading(true);
            const response = await fetch("https://localhost:7019/api/Product/" + id, {
                method: "Get",
                headers: {'Content-Type': "application/json"},
                credentials: 'include',
                mode: "cors",
            });
            setProduct(await response.json());
            setLoading(false);
        }
        getProduct();
    }, []);

    const Loading = () => {
        return(
            <>
               <div className="col-md-6">
                   <Skeleton height = {400}/>
                   </div>
            </>
        )
    }
    console.log(product)
    const ShowProduct = () => {
        return(
            <>
                <div className="col-md-6">
                    <img src="Https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRIoRaByLV2y9PASZdOmK3sKQ3z9BBu_mkWd0Vm7-W3ag&s" height = "400px" width = "500px"/>

                </div>
                <div className = "col-md-6">
                   <h1 className = "display-5">{product.name}</h1>

                <h2 className = "display-6 fw-bold my-4">
                ${product.price}
                </h2>
                    <p className="lead">{product.description}</p>
                    <button className="btn btn-outline-dark px-4 py-2" onClick={() => addProduct(product)}>
                        Add to Cart
                    </button>
                    <NavLink to="/cart" className = "btn btn-outline-dark ms-2 px-3 py-2">
                        Go To Cart
                    </NavLink>
                </div>
            </>
        )
    }
    return(
        <div>
        <div className = "container py-5">
            <div className = "row py-5">
                {loading ? <Loading/> : <ShowProduct/>}
            </div>
        </div>
        </div>
    );

}
export default Product;
