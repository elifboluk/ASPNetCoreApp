import React from "react";

export default function App() {
  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <h1>Hello Bootstrap!</h1>

          {renderOrderDetailsTable()}
        </div>
      </div>      
    </div>
  );

function renderOrderDetailsTable(){
  return (
    <div className="table-responsive mt-15">
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
          <tr>
            <th scope='row'>1</th>
            <td>OrderDetailId 1 Total</td>
            <td>OrderDetailId 1 ProductId</td>
            <td>OrderDetailId 1 Product</td>
            <td>OrderDetailId 1 OrderId</td>
            <td>OrderDetailId 1 Order</td>
            <td>
              <button className="btn btn-dark btn-lg active mx-9 my-3">Update</button>
              <button className="btn btn-danger btn-lg active">Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  );
}
}


