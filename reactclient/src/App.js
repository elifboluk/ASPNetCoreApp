import React, { useState } from "react";
import Constants from "./utilities/Constants";
import OrderDetailCreateForm from "./components/OrderDetailCreateForm";

export default function App() {
  const [orderdetails, setOrderDetails] = useState([]);
  const [showingCreateNewOrderDetailForm, setShowingCreateNewOrderDetailForm] = useState(false);

  function getOrderDetails() {
    const url = Constants.API_URL_GET_ALL_ORDERDETAILS;

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
          {showingCreateNewOrderDetailForm === false && (
            <div>
              <h1>ASP.Net Core App</h1>
              <div className="mt-5">
                <button onClick={getOrderDetails} className='btn btn-dark btn-large w-100'>Get Order Details from server</button>
                <button onClick={() => setShowingCreateNewOrderDetailForm(true)} className='btn btn-secondary btn-large w-100 mt-4'>Create New Order Detail </button>
              </div>
            </div>
          )}

          {(orderdetails.length > 0 && showingCreateNewOrderDetailForm === false) && renderOrderDetailsTable()}

          {showingCreateNewOrderDetailForm && <OrderDetailCreateForm onOrderDetailCreated={onOrderDetailCreated} />}
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
              <th scope="col">Product Name</th>
              <th scope="col">OrderId</th>
              <th scope="col">Ordering Company Name</th>
              <th scope="col">CRUD Operations</th>
            </tr>
          </thead>
          <tbody>
            {orderdetails.map((orderdetails) => (
              <tr key={orderdetails.orderDetailId}>
                <th scope='row'>{orderdetails.orderDetailId}</th>
                <td>{orderdetails.total}</td>
                <td>{orderdetails.productId}</td>
                <td>{orderdetails.productname}</td>
                <td>{orderdetails.orderId}</td>
                <td>{orderdetails.orderingcompanyname}</td>
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

  function onOrderDetailCreated(createdOrderDetail) {
    setShowingCreateNewOrderDetailForm(false);
    if (createdOrderDetail === null) {
      return;
    }
    alert(`Order Detail succesfully created. After clicking OK, your new order detail tilted "${createdOrderDetail.total}" will show up in the table below.`);

    getOrderDetails();
  }
}


