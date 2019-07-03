import { Injectable } from "@angular/core";
import { PaymentDetail } from "./payment-detail.model";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { environment } from "../../environments/environment";
import { ApiResponse } from "./response-adapter/api-response-adapter";

@Injectable({
  providedIn: "root"
})
export class PaymentDetailService {
  formData: PaymentDetail;
  list: PaymentDetail[];
  constructor(private httpClient: HttpClient) {}
  postPaymentDetail(): Observable<any> {
    return this.httpClient.post(environment.rootUrl, this.formData);
  }
  updatePaymentDetail(): Observable<any> {
    return this.httpClient.put(
      environment.rootUrl + this.formData.paymentDetailsId,
      this.formData
    );
  }
  detailPaymentDetail(id: number): Observable<any> {
    return this.httpClient.delete(environment.rootUrl + id);
  }
  refershList() {
    return this.httpClient
      .get(environment.rootUrl)
      .toPromise()
      .then((res: ApiResponse) => {
        if (res.statusCode === 200) this.list = res.result as PaymentDetail[];
        else this.list = [];
      });
  }
}
