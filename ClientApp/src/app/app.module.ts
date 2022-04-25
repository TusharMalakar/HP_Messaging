import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { MessageComponent } from './components/message-box/message.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { AuthGuardService as AuthGuard} from './services/auth-gard.service';
import { ReactiveFormsModule } from '@angular/forms';
import { ChatService } from './services/chat.service';
import { EditMessageDialog } from './components/edit-message/edit-message.dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatFormFieldModule} from '@angular/material/form-field';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    MessageComponent,
    SignInComponent,
    EditMessageDialog
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    RouterModule.forRoot([
      {
        path: '',
        component: MessageComponent,
        pathMatch: 'full'
        ,canActivate:[AuthGuard]
      },
      {
        path: 'signIn',
        component: SignInComponent
      }

      ,{ path: '**', redirectTo: 'signIn' }
    ]),
    BrowserAnimationsModule
  ],
  exports: [RouterModule],
  providers: [
            AuthGuard,
            ChatService
            ],
  bootstrap: [AppComponent]
})
export class AppModule { }
