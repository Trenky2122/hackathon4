import {Link} from "react-router-dom";
import React from "react";

const EntranceRequestDetailed = () => {
    return(
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-10 homepageForm"}>
                    <h2>Detail žiadosti</h2>
                    <div className={"row"}>
                        <div style={{textAlign: "start"}} className={"col-3"}>
                            Stav:
                        </div>
                        <div style={{textAlign: "start"}} className={"col-7 p-0"}>
                            Čaká na schválenie
                        </div>
                        <div style={{textAlign: "start"}} className={"col-3"}>
                            Typ:
                        </div>
                        <div style={{textAlign: "start"}} className={"col-7 p-0"}>
                            Rezident
                        </div>
                        <div style={{textAlign: "start"}} className={"col-3"}>
                            Meno:
                        </div>
                        <div style={{textAlign: "start"}}className={"col-7 p-0"}>
                            Jozef
                        </div>
                        <div style={{textAlign: "start"}} className={"col-3"}>
                            Priezvisko:
                        </div>
                        <div style={{textAlign: "start"}} className={"col-7 p-0"}>
                            Šikovný
                        </div>
                        <div style={{textAlign: "start"}} className={"col-3"}>
                            Štátna príslušnosť:
                        </div>
                        <div style={{textAlign: "start"}} className={"col-7 p-0"}>
                            SK
                        </div>
                        <div style={{textAlign: "start"}} className={"col-3"}>
                            Rodné číslo:
                        </div>
                        <div style={{textAlign: "start"}} className={"col-7 p-0"}>
                            660211/0999
                        </div>
                        <div style={{textAlign: "start"}} className={"col-3"}>
                            Vozidlá:
                        </div>
                        <div style={{textAlign: "start"}} className={"col-7 p-0"}>
                            BA 2100 LG, BT 4578 NM
                        </div>
                        <div style={{textAlign: "start"}} className={"col-3"}>
                            Povolené miesta:
                        </div>
                        <div style={{textAlign: "start"}} className={"col-7 p-0"}>
                            Kapitulská
                        </div>
                        <div style={{textAlign: "start"}} className={"col-3"}>
                            Dátum platnosti od:
                        </div>
                        <div style={{textAlign: "start"}} className={"col-7 p-0"}>
                            24.05.2023
                        </div>
                        <div style={{textAlign: "start"}} className={"col-3"}>
                            Ročná:
                        </div>
                        <div style={{textAlign: "start"}} className={"col-7 p-0"}>
                            Áno
                        </div>
                        <div style={{textAlign: "start"}} className={"col-3"}>
                            Súbory:
                        </div>
                        <div style={{textAlign: "start"}} className={"col-7 p-0"}>
                            <Link to={""}>Žiadosť.pdf</Link>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default EntranceRequestDetailed