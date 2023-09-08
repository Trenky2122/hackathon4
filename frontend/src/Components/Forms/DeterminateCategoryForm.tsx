import React from "react";
import {Button, Container, Nav, Navbar, Offcanvas} from "react-bootstrap";
import {Link, useNavigate} from "react-router-dom";
import LocalizedStrings from "react-localization";

const DeterminateCategoryForm = () => {
    let navigate = useNavigate();
    const localization = new LocalizedStrings({
        en: {
            title: "Determination to the category",
        },
        sk: {
            title: "Zistenie skupiny",
        }
    });
    return (
        <div>
            <div>{localization.title}</div>
            <Button className={"me-2"} variant={"danger"} onClick={() => navigate("/poziadanieVstupu/vstupZamietnuty")}>Vstup mi nebol povolený</Button>
            <Button className={"me-2"} variant={"success"} onClick={() => navigate("/poziadanieVstupu/ziskanieEmailu")}>Skipujem proces určovania, žiadam o vstup</Button>
        </div>
    )
}

export default DeterminateCategoryForm;