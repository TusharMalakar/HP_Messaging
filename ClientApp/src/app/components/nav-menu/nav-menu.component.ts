import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(private router: Router){

  }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
    this.SignOut();
  }

  hasValidToken(){
    return localStorage.getItem('authHash')!=null;
  }

  SignOut(){
    localStorage.removeItem('profile');
    localStorage.removeItem('authHash');
    this.router.navigate(['signIn']);
  }
}
