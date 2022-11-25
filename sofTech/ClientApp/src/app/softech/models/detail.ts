import { Article } from "./article";

export class Detail {
    code: number = 0;
    invoiceNumber: number = 0;
    article: Article | undefined;
    articleReference: string = "";
    amount: number = 0;
    unitPrice: number = 0;
    total: number = 0;
}
