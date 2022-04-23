import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { MessageComponent } from './components/message/message.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { AuthGuardService as AuthGuard} from './services/auth-gard.service';
import { ReactiveFormsModule } from '@angular/forms';
import { ChatService } from './services/chat.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    MessageComponent,
    SignInComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
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
    ])
  ],
  exports: [RouterModule],
  providers: [AuthGuard, ChatService],
  bootstrap: [AppComponent]
})
export class AppModule { }
