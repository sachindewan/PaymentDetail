import { Component, OnInit } from "@angular/core";
import { PaymentDetailService } from "../../shared/payment-detail.service";
import { NgForm } from "@angular/forms";
import { ApiResponse } from "../../shared/response-adapter/api-response-adapter";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-payment-detail",
  templateUrl: "./payment-detail.component.html",
  styles: []
})
export class PaymentDetailComponent implements OnInit {
  readonly title = "Payment Detail Register";
  constructor(
    private service: PaymentDetailService,
    private toaterService: ToastrService
  ) {}

  ngOnInit() {
    debugger;
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    debugger;
    if (form != null) {
      form.resetForm();
    }
    this.service.formData = {
      paymentDetailsId: 0,
      cardNumber: "",
      cardOwnerName: "",
      cVV: "",
      expirationDate: ""
    };
  }
  onSubmit(form: NgForm) {
    if (form.value.paymentDetailsId == 0) {
      this.inserRecord(form);
    } else {
      this.updateRecord(form);
    }
  }

  private inserRecord(form: NgForm) {
    this.service.postPaymentDetail().subscribe(
      (res: ApiResponse) => {
        this.toaterService.success(res.message, this.title);
        if (res.statusCode === 200 || res.statusCode === 201)
          this.resetForm(form);

        this.service.refershList();
      },
      (err: ApiResponse) => {
        this.toaterService.error(err.message, this.title);
      }
    );
  }
  private updateRecord(form: NgForm) {
    this.service.updatePaymentDetail().subscribe(
      (res: ApiResponse) => {
        this.toaterService.info(res.message, this.title);
        if (res.statusCode === 200) this.resetForm(form);
        this.service.refershList();
      },
      (err: ApiResponse) => {
        this.toaterService.error(err.message, this.title);
      }
    );
  }
}
