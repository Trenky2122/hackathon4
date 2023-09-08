import React from "react";
import {Button, Container, Nav, Navbar, Offcanvas} from "react-bootstrap";
import {Link, useNavigate} from "react-router-dom";
import LocalizedStrings from "react-localization";

const PermitNotGrantedComponent = () => {
    let navigate = useNavigate();
    const localization = new LocalizedStrings({
        en: {
            title: "Permit not granted",
        },
        sk: {
            title: "Prepáčte, na povolenie nemáte nárok",
        }
    });
    return (
        <div>
            <div>{localization.title}</div>
            <Button className={"me-2"} variant={"success"} onClick={() => navigate("/")}>Homepage</Button>
        </div>
    )
}

export default PermitNotGrantedComponent;