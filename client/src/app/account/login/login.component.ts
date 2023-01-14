import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../account.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  returnUrl: string;
  
  constructor(
    private accountService: AccountService, 
    private router: Router,
     private activatedRoute: ActivatedRoute 
  ) { }

  ngOnInit(): void {
    // Set a return URL if we have it. If not --> return to Shop
    this.returnUrl = this.activatedRoute.snapshot.queryParams.returnUrl || '/shop';
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = new FormGroup({
      // FormControl([initial state of field], [field validation])
      email: new FormControl('', [
        Validators.required, 
        Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')
      ]),
      password: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    this.accountService.login(this.loginForm.value).subscribe(() => {
      this.router.navigateByUrl(this.returnUrl);
      console.log('user logged in');
    }, error => {
      console.log(error);
    })
  }
}
