import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { GetPeopleComponent } from './softech/get-people/get-people.component';
import { GetInvoiceComponent } from './softech/get-invoice/get-invoice.component';
import { GetUsersComponent } from './softech/get-users/get-users.component';
import { GetArticleComponent } from './softech/get-article/get-article.component';
import { PostArticleComponent } from './softech/post-article/post-article.component';
import { PostUsersComponent } from './softech/post-users/post-users.component';
import { PostPeopleComponent } from './softech/post-people/post-people.component';
import { PostInvoiceComponent } from './softech/post-invoice/post-invoice.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    GetPeopleComponent,
    GetInvoiceComponent,
    GetUsersComponent,
    GetArticleComponent,
    PostArticleComponent,
    PostUsersComponent,
    PostPeopleComponent,
    PostInvoiceComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
