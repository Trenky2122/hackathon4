import React, {useEffect, useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";
import LocalizedStrings from "react-localization";

const UserEntriesHistoryComponent = () => {
    let navigate = useNavigate();
    const localization = new LocalizedStrings({
        en: {
            title: "Show user entries",
        },
        sk: {
            title: "História vstupov používateľa",
        }
    });

    useEffect(() => {
        // Zavolaj backend service aby si dostal dáta o posledných vstupoch o používateľovi
        // Dáta: kde, kedy vosiel, kedy odisiel, straveny cas dnu, poplatok, stav zaplatenia
    },  [])

    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-3 homepageForm"}>
                    <h1 style={{marginBottom: "30px"}}>{localization.title} </h1>
                    <p>Neevidujeme vstupy</p>
                    <Button className={"me-2"} variant={"success"} onClick={() => navigate("/")}>Domov</Button>
                </div>
            </div>
        </div>
    )
}

export default UserEntriesHistoryComponent;