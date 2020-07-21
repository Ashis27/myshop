import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators'
import { AuthService } from 'src/app/shared/authentication/auth.service';
import { IRegistration } from 'src/app/shared/models/registration.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  success: boolean;
  error: string;
  userRegistration: IRegistration = { FirstName: "", Email: "", Password: "", ConfirmPassword: "" }
  submitted: boolean = false;

  constructor(private authService: AuthService, private spinner: NgxSpinnerService) {

  }

  ngOnInit() {
  }

  onSubmit() {

    this.spinner.show();

    this.authService.register(this.userRegistration)
      .pipe(finalize(() => {
        this.spinner.hide();
      }))
      .subscribe(result => {
        if (result) {
          this.success = true;
        }
      },
        error => {
          this.error = error;
        });
  }
}
