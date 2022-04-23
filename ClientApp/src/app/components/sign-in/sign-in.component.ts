import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { ChatUserModel } from 'src/app/models/chat-user.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './sign-in.component.html'
})
export class SignInComponent {

  constructor(private _authservice:AuthService, private router: Router) {
  }

  SignIn(email: string, password: string){
    this._authservice.SignIn(email, password).subscribe((profile:ChatUserModel)=>{
      localStorage.setItem('authHash', profile.authHash);
      this.router.navigate(['']);
    });
  }

  SignOut(){
    localStorage.removeItem('authHash');
  }

}

