import React, {useEffect, useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";

const RequestsComponent = () => {
    let navigate = useNavigate();

    useEffect(() => {
        //
    },  [])

    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-8 homepageForm"}>
                    <h1 style={{marginBottom: "30px"}}>Žiadosti používateľa</h1>
                    <h2>Povolené</h2>
                    <p>Žiadne</p>
                    <h2>Spracuváva sa</h2>
                    <p>Žiadne</p>
                    <h2>Zamietnuté</h2>
                    <p>Žiadne</p>
                    <Button className={"me-2"} variant={"success"} onClick={() => navigate("/ziadost/kategorizacia")}>Podať žiadosť</Button>
                </div>
            </div>
        </div>
    )
}

export default RequestsComponent;