import React, {useEffect, useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";
import LocalizedStrings from "react-localization";

const RequestsComponent = () => {
    let navigate = useNavigate();
    const localization = new LocalizedStrings({
        en: {
            title: "User requests",
        },
        sk: {
            title: "Žiadosti používateľa",
        }
    });

    useEffect(() => {
        //
    },  [])

    return (
        <div>
            <h1>{localization.title}</h1>
            <h2>Povolené</h2>
            <p>Žiadne</p>
            <h2>Spracuváva sa</h2>
            <p>Žiadne</p>
            <h2>Zamietnuté</h2>
            <p>Žiadne</p>
            <Button className={"me-2"} variant={"success"} onClick={() => navigate("/ziadost/kategorizacia")}>Podať žiadosť</Button>
        </div>
    )
}

export default RequestsComponent;