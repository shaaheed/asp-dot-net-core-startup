import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UsersHttpService } from 'src/services/http/users-http.service';

@Component({
  selector: 'app-users-add',
  templateUrl: './users-add.component.html',
  // styleUrls: ['./resources-add.component.scss']
})
export class UsersAddComponent {

  firstname: string;
  lastname: string;
  email: string;
  selectedGroups = [];
  userGroups = [];
  resources: [];
  mode: string = 'add';
  tableHeader = {}
  loading = false;

  validateForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private usersHttpService: UsersHttpService
  ) { }

  ngOnInit(): void {
    
    this.validateForm = this.fb.group({
      firstname: [null, [Validators.required]],
      lastname: [],
      userGroup: [],
      email: [null, [Validators.required, Validators.email]],
    });

    if(this.mode == 'edit') {
      this.validateForm.controls.email.disable();
    }

    this.getUserGroups();

  }

  submitForm(): void {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }
  }

  getUserGroups() {
    this.usersHttpService.getUserGroups().subscribe(
      (res: any[]) => {
        this.userGroups = res;
      },
      err => {
        console.log(err);
      }
    );
  }


}
