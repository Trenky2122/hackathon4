import React, {useEffect} from "react";
import {Container, Nav, Navbar, Offcanvas} from "react-bootstrap";
import {Link, useLocation, useNavigate} from "react-router-dom";

const NavigationComponent = () => {
    let navigate = useNavigate();
    let location = useLocation();

    useEffect(() => {
        console.log(location)
    }, [location])

    return (
        <Navbar style={location.pathname === "/" ? {backgroundColor: 'transparent'} : {}} expand={false} >
            <Container fluid>
                <Navbar.Brand onClick={() => navigate("/")}>
                    {location.pathname !== "/" ? "Domov" : ""}
                </Navbar.Brand>
                <div>
                    <Navbar.Toggle aria-controls={"offcanvasNavbar"}/>
                </div>
                <Navbar.Offcanvas id={"offcanvasNavbar"} aria-labelledby={"offcanvasNavbarLabel"} placement={"end"}>
                    <Offcanvas.Header closeButton>
                        <Offcanvas.Title id="offcanvasNavbarLabel">Menu</Offcanvas.Title>
                    </Offcanvas.Header>
                    <Offcanvas.Body>
                        <Nav className={"justify-content-start flex-grow-1 pe-3"}>
                            <a>Pre všetkých:</a>
                            <Navbar.Toggle aria-controls={"offcanvasNavbar"}>
                                <Link className={"nav-link"} to={"/"}>Domov</Link>
                            </Navbar.Toggle>
                            <Navbar.Toggle aria-controls={"offcanvasNavbar"}>
                                <Link className={"nav-link"} to={"/registracia/ziskanieEmailu"}>Registrácia</Link>
                            </Navbar.Toggle>
                            <Navbar.Toggle aria-controls={"offcanvasNavbar"}>
                                <Link className={"nav-link"} to={"/prihlasenie"}>Prihlásenie</Link>
                            </Navbar.Toggle>
                            <a>Pre prihlásených:</a>
                            <Navbar.Toggle aria-controls={"offcanvasNavbar"}>
                                <Link className={"nav-link"} to={"/profil"}>Profil</Link>
                            </Navbar.Toggle>
                            <Navbar.Toggle aria-controls={"offcanvasNavbar"}>
                                <Link className={"nav-link"} to={"/profil/ziadosti"}>Žiadosti používateľa</Link>
                            </Navbar.Toggle>
                            <Navbar.Toggle aria-controls={"offcanvasNavbar"}>
                                <Link className={"nav-link"} to={"/profil/historiaVstupov"}>História vstupov používateľa</Link>
                            </Navbar.Toggle>
                            <a>Admin:</a>
                            <Navbar.Toggle aria-controls={"offcanvasNavbar"}>
                                <Link className={"nav-link"} to={"/admin/ziadosti"}>Žiadosti</Link>
                            </Navbar.Toggle>
                        </Nav>
                    </Offcanvas.Body>
                </Navbar.Offcanvas>
            </Container>
        </Navbar>
    )
}

export default NavigationComponent;