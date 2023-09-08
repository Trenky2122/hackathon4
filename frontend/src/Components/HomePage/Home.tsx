import LocalizedStrings from "react-localization";
import React from "react";
import {useNavigate} from "react-router-dom";
import Button from "react-bootstrap/esm/Button";

const HomeComponent = () => {
    let navigate = useNavigate();
    const localization = new LocalizedStrings({
        en: {
            title: "Welcome.",
        },
        sk: {
            title: "Vitajte.",
        }
    })
    return (
        <div>
            <h1>{localization.title}</h1>
            <Button className={"me-2"} variant={"success"} onClick={() => navigate("/poziadanieVstupu/zistenieKategorie")}>Požiadať o vstup</Button>
        </div>
    )
}

export default HomeComponent;