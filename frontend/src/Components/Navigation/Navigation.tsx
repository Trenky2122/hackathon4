import React from "react";
import {Container, Nav, Navbar, Offcanvas} from "react-bootstrap";
import {Link, useNavigate} from "react-router-dom";
import LocalizedStrings from "react-localization";

const NavigationComponent = () => {
    let navigate = useNavigate();
    const localization = new LocalizedStrings({
        en: {
            home: "Home",
            permitRegistration: "Registrácia povolenia",
        },
        sk: {
            home: "Domov",
            permitRegistration: "Registrácia povolenia",
        }
    });
    return (
        <Navbar bg={"light"} expand={false}>
            <Container fluid>
                <Navbar.Brand onClick={() => navigate("/")}>
                    {localization.home}
                </Navbar.Brand>
                <Navbar.Offcanvas id={"offcanvasNavbar"} aria-labelledby={"offcanvasNavbarLabel"} placement={"end"}>
                    <Offcanvas.Header closeButton>
                        <Offcanvas.Title id="offcanvasNavbarLabel">Menu</Offcanvas.Title>
                    </Offcanvas.Header>
                    <Offcanvas.Body>
                        <Nav className={"justify-content-end flex-grow-1 pe-3"}>
                            <a>Basic user:</a>
                            <Navbar.Toggle aria-controls={"offcanvasNavbar"}>
                                <Link className={"nav-link"} to={"/"}>{localization.home}</Link>
                            </Navbar.Toggle>
                            <Navbar.Toggle aria-controls={"offcanvasNavbar"}>
                                <Link className={"nav-link"} to={"permitRegistration"}>{localization.permitRegistration}</Link>
                            </Navbar.Toggle>
                        </Nav>
                    </Offcanvas.Body>
                </Navbar.Offcanvas>
            </Container>
        </Navbar>
    )
}

export default NavigationComponent;