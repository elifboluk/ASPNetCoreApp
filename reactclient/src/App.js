import React, { useState } from "react";

export default function App() {
  const [orderdetails, setOrderDetails] = useState([]);

  function getOrderDetails() {
    const url = 'https://localhost:7215/get-all-orderdetails';
    fetch(url, {
      method: 'GET'

    }).then(response => response.json())
      .then(orderdetailsFromServer => {
        console.log(orderdetailsFromServer);
        setOrderDetails(orderdetailsFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });

  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <div>
            <h1>ASP.Net Core App</h1>
            <div className="mt-5">
              <button onClick={getOrderDetails} className='btn btn-dark btn-large w-100'>Get Order Details from server</button>
              <button onClick={() => { }} className='btn btn-secondary btn-large w-100 mt-4'>Create New Order Detail </button>

            </div>
          </div>

          {orderdetails.length > 0 && renderOrderDetailsTable()}
        </div>
      </div>
    </div>
  );

  function renderOrderDetailsTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">OrderDetailId(PK)</th>
              <th scope="col">Total</th>
              <th scope="col">ProductId</th>
              <th scope="col">Product</th>
              <th scope="col">OrderId</th>
              <th scope="col">Order</th>
              <th scope="col">CRUD Operations</th>
            </tr>
          </thead>
          <tbody>
            {orderdetails.map((orderdetails) => (
              <tr key={orderdetails.orderdetailId}>
                <th scope='row'>{orderdetails.orderdetailId}</th>                
                <td>{orderdetails.total}</td>
                <td>{orderdetails.productId}</td>
                <td>{orderdetails.Product}</td>
                <td>{orderdetails.orderId}</td>
                <td>{orderdetails.Order}</td> 
                <td>
                  <button className="btn btn-dark btn-lg active mx-9 my-3">Update</button>
                  <button className="btn btn-danger btn-lg active">Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        <button onClick={() => setOrderDetails([])} className="btn btn-dark btn-lg w-100">Empty React Order Details array.</button>
      </div>
    );
  }
}


