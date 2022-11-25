import { Detail } from "./detail";
import { Person } from "./person";

export class Invoice {
    invoiceNumber: number = 0;
    employeeID: string = "";
    employee: Person | undefined;
    invoiceData: Date| undefined;
    concept: string = "";
    details: Detail[] | undefined;

}
