import { Component } from '@angular/core';
import { UntypedFormGroup, UntypedFormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/services/auth.service';
import { HttpService } from 'src/services/http/http.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  firstname: string;
  lastname: string;
  email: string;
  selectedGroups = [];
  userGroups = [];
  resources: [];
  mode: string = 'add';
  tableHeader = {}

  validateForm: UntypedFormGroup;

  constructor(
    private fb: UntypedFormBuilder,
    private authService: AuthService,
    private httpService: HttpService
  ) { }

  ngOnInit(): void {

    this.validateForm = this.fb.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required]],
      remember: []
    });

    if (this.mode == 'edit') {
      this.validateForm.controls.email.disable();
    }

  }

  submitForm(): void {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }

    const body = {
      username: this.validateForm.controls.email.value,
      password: this.validateForm.controls.password.value
    }

    this.httpService.post('authenticate/login', body).subscribe(
      (res: any) => {
        if (res.authenticated) {
          // this.authService.signin(body.username, body.password)
        }
      },
      error => {
        console.log(error);
      });

  }


}
