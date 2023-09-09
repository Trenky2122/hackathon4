import React, {useEffect, useState} from "react";
import {Table} from "react-bootstrap";
import {TableBody, TableCell, TableHead, TableRow} from "@material-ui/core";
import {EntranceRequestBase, RequestStateEnum, RequestTypeEnum} from "../../Models/Models";
import BackendService from "../../Service/BackendService";
import {Link} from "react-router-dom";

const AdminMainPage = () =>{

    const [entranceRequests, setEntranceRequests]:[EntranceRequestBase[], any] = useState([{
        RequesterName:"Ján",
        RequesterSurname:"Vysoký",
        Id:3,
        Date:new Date(),
        Type: RequestTypeEnum.CleaningSecurity,
        State:RequestStateEnum.Accepted,
        Caption:"12"
    },
        {
            RequesterName:"Milan",
            RequesterSurname:"Malý",
            Id:3,
            Date:new Date(),
            Type: RequestTypeEnum.CleaningSecurity,
            State:RequestStateEnum.Accepted,
            Caption:"12"
    }
    ])

    useEffect(() =>{
        BackendService.getEntranceRequestsBase().then(res => {
            //setEntranceRequests(() => res.data);
        }).catch(ex => {
            console.log(ex)
        })
    }, [])

    return(
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-10 homepageForm"}>
                    <h2>Žiadosti</h2>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>Stav</TableCell>
                                <TableCell>Typ</TableCell>
                                <TableCell>Meno</TableCell>
                                <TableCell>Priezvisko</TableCell>
                                <TableCell>Názov</TableCell>
                                <TableCell>Dátum</TableCell>
                                <TableCell>Viac</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {
                                entranceRequests.map((req, index) => (
                                    <TableRow key={index}>
                                        <TableCell>Čaká na schválenie</TableCell>
                                        <TableCell>Rezident</TableCell>
                                        <TableCell>{req.RequesterName}</TableCell>
                                        <TableCell>{req.RequesterSurname}</TableCell>
                                        <TableCell>{req.Caption}</TableCell>
                                        <TableCell>{req.Date.getDay()}.{req.Date.getMonth()}.{req.Date.getFullYear()}</TableCell>
                                        <TableCell><Link to={"/"}>Info</Link></TableCell>
                                    </TableRow>
                                ))
                            }
                        </TableBody>
                    </Table>
                </div>
            </div>
        </div>
    )
}
export default AdminMainPage