import React, {useState, useEffect} from "react";
import Skeleton from 'react-loading-skeleton'
import {NavLink} from "react-router-dom";



const Products = () => {

    const [data, setData] = useState([]);
    const [filter, setFilter] = useState(data);
    const [loading, setLoading] = useState(false);
    let componentMounted = true;

    useEffect(() => {
        const getProducts = async () => {
            setLoading(true);
            const response = await fetch("https://localhost:7019/api/product", {
                method: "Get",
                headers: {'Content-Type': "application/json"},
                credentials: 'include',
                mode: "cors",
            });

            if (componentMounted) {
                setData(await response.clone().json());
                setFilter(await response.json());
                setLoading(false);
                console.log(filter);
            }

            return () => {
                componentMounted = false;
            }
        }
        getProducts();
    }, []);

    const Loading = () => {
        return (
            <>
             <div className = "col-md-3">
                 <Skeleton height = {350}/>
             </div>
            </>
        )
    }


    const ShowProducts = () => {
        return (
            <>
                <div className="buttons d-flex justify-content-center mb-5 pb-5">
                    <button className="btn btn-outline-dark me-2" onClick={(() => setFilter(data))}>All
                    </button>
                </div>
                {filter.map((product: any) => {
                    return (
                        <>
                            <div className="col-md-3 mb-4">
                                <div className="card h-100 text-center p-4 " key = {product.id}>
                                    <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRIoRaByLV2y9PASZdOmK3sKQ3z9BBu_mkWd0Vm7-W3ag&s" className="card-img-top" height = "250px"/>
                                    <div className="card-body">
                                        <h5 className="card-title mb-0">{product.name.substring(0,15)}</h5>
                                        <p className="card-te xt">${product.price}</p>
                                        <NavLink to = {'/products/' + product.id} className="btn btn-outline-dark">Buy Now</NavLink>
                                    </div>
                                </div>
                            </div>
                        </>
                    );
                })}
            </>
        );
    };


    return (
        <div>
            <div className="container my-5 py-5">
                <div className="row">
                    <div className="col-12 mb-5">
                        <h1 className="display-6 fw-bolder text-center">Latest Products</h1>
                    </div>
                </div>
                <div className="row justify-content-center">
                    {loading ? <Loading/> : <ShowProducts/>}
                </div>
            </div>
        </div>
    )


}
        export default Products;