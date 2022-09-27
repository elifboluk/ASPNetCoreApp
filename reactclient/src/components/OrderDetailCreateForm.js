import React, { useState } from 'react'
import Constants from '../utilities/Constants'

export default function OrderDetailCreateForm(props) {
    const [formData, setFormData] = useState(initialFormData);

    const initialFormData = Object.freeze({
        total:"Order Detail x",
        productid:"x",
        product:"This is Order Detail x and it has are interesting product.",
        orderid:"x",
        order:"This is Order Detail x and it has are interesting order."
    });

    const handleChange=(e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit=(e) => {
        e.preventDefault();

        const orderdetailToCreate = {
            orderdetailId:0,
            total: formData.total,
            productid: formData.productid,
            product: formData.product,
            orderid: formData.orderid,
            order: formData.order
        };
        const url = Constants.API_URL_CREATE_ORDERDETAIL;

        fetch(url, {
            method: 'ORDERDETAIL',
            headers: {
                'Content-Type':'application/json'
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
    <div>
        <form className="w-100 px-5">
            <h1 className="mt-5">Create new order detail</h1>

            <div className="mt-5">
                <label clasName="h3 form-label">Order Detail Total</label>
                <input value={formData.total} name="total" type="text" className="form-control" onChange={handleChange}/>
            </div>

            <div className="mt-4">
                <label clasName="h3 form-label">Order Detail ProductId</label>
                <input value={formData.productid} name="productid" type="text" className="form-control" onChange={handleChange}/>
            </div>

            <div className="mt-4">
                <label clasName="h3 form-label">Order Detail Product</label>
                <input value={formData.product} name="product" type="text" className="form-control" onChange={handleChange}/>
            </div>

            <div className="mt-4">
                <label clasName="h3 form-label">Order Detail OrderId</label>
                <input value={formData.orderid} name="orderid" type="text" className="form-control" onChange={handleChange}/>
            </div>

            <div className="mt-4">
                <label clasName="h3 form-label">Order Detail Order</label>
                <input value={formData.order} name="order" type="text" className="form-control" onChange={handleChange}/>
            </div>

            <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
            <button onClick={() => props.onOrderDetailCreated(null)} className="btn btn-secondary btn-lg w-100 mt-3">Cancel</button>
        </form>
    </div>
  );
}
