import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ChatUserModel } from 'src/app/models/chat-user.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './sign-in.component.html'
})
export class SignInComponent implements OnInit {

  emailPattern = "[A-Za-z0-9._%-]+@[A-Za-z0-9._%-]+\\.[a-z]{2,3}";

  constructor(private _authservice:AuthService, private router: Router) {}
  ngOnInit(){}

  profileForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl('', [Validators.required, Validators.pattern(this.emailPattern)]),
    password: new FormControl('', [Validators.required])
  });

  SignIn(){
    const profileModel = this.profileForm.value as ChatUserModel;
    this._authservice.SignIn(profileModel).subscribe((profile:ChatUserModel)=>{
      localStorage.setItem('authHash', profile.authHash);
      localStorage.setItem('profile', JSON.stringify(profile));
      this.router.navigate(['']);
    });
  }
}

