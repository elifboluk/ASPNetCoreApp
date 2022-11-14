import React, { useState } from 'react'
import Constants from '../utilities/Constants'

export default function OrderDetailCreateForm(props) {

    const initialFormData = Object.freeze({
        total: "Order Detail x",
        productname: "x",
        productquantity: "This is Order Detail x and it has are interesting product.",
        productprice: "x",
        orderingcompanyname: "This is Order Detail x and it has are interesting order.",
        orderdate:"x"
    });

    const [formData, setFormData] = useState(initialFormData);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        const orderdetailToCreate = {           
            orderdetailId: 0,
            total: formData.total,
            productname: formData.productname,
            productquantity: formData.productquantity,
            productpice: formData.productprice,
            orderingcompanyname: formData.orderingcompanyname,
            orderdate: formData.orderdate
        };
        const url = Constants.API_URL_CREATE_ORDERDETAIL;

        fetch(url, {
            method: 'ORDERDETAIL',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(orderdetailToCreate)
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            });
        props.onOrderDetailCreated(orderdetailToCreate);
    };


    return (
        <form className="w-100 px-5">
            <h1 className="mt-5">Create new order detail</h1>

            <div className="mt-5">
                <label clasName="h3 form-label">Order Detail Total</label>
                <input value={formData.total} name="total" type="text" className="form-control" onChange={handleChange} />
            </div>

            <div className="mt-4">
                <label clasName="h3 form-label">Order Detail Product Name</label>
                <input value={formData.productname} name="productid" type="text" className="form-control" onChange={handleChange} />
            </div>

            <div className="mt-4">
                <label clasName="h3 form-label">Order Detail Product Quantity</label>
                <input value={formData.productquantity} name="product" type="text" className="form-control" onChange={handleChange} />
            </div>

            <div className="mt-4">
                <label clasName="h3 form-label">Order Detail Price</label>
                <input value={formData.productprice} name="orderid" type="text" className="form-control" onChange={handleChange} />
            </div>

            <div className="mt-4">
                <label clasName="h3 form-label">Order Detail Company Name</label>
                <input value={formData.orderingcompanyname} name="order" type="text" className="form-control" onChange={handleChange} />
            </div>

            <div className="mt-4">
                <label clasName="h3 form-label">Order Detail Order Date</label>
                <input value={formData.orderdate} name="order" type="text" className="form-control" onChange={handleChange} />
            </div>

            <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
            <button onClick={() => props.onOrderDetailCreated(null)} className="btn btn-secondary btn-lg w-100 mt-3">Cancel</button>
        </form>
    );
}
