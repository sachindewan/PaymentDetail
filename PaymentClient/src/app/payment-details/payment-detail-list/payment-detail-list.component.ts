import { Component, OnInit } from "@angular/core";
import { PaymentDetailService } from "../../shared/payment-detail.service";
import { PaymentDetail } from "../../shared/payment-detail.model";
import { ToastrService } from "ngx-toastr";
import { ApiResponse } from "../../shared/response-adapter/api-response-adapter";

@Component({
  selector: "app-payment-detail-list",
  templateUrl: "./payment-detail-list.component.html",
  styles: []
})
export class PaymentDetailListComponent implements OnInit {
  constructor(
    private service: PaymentDetailService,
    private toasterService: ToastrService
  ) {}

  ngOnInit() {
    this.service.refershList();
  }

  populateForm(pd: PaymentDetail) {
    this.service.formData = Object.assign({}, pd);
  }
  deleteRecord(id: number, event: Event) {
    event.stopPropagation();
    if (confirm("are you sure , do you want to delete the record?")) {
      this.service.detailPaymentDetail(id).subscribe(
        (res: ApiResponse) => {
          debugger;
          if (res.statusCode === 200) {
            this.toasterService.warning(res.message, "Payment Detail Register");
            this.service.refershList();
          }
        },
        (err: ApiResponse) => {
          this.toasterService.error(err.message, "Payment Detail Register");
        }
      );
    }
  }
}
