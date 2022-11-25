import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { GetArticleComponent } from './softech/get-article/get-article.component';
import { GetInvoiceComponent } from './softech/get-invoice/get-invoice.component';
import { GetPeopleComponent } from './softech/get-people/get-people.component';
import { PostArticleComponent } from './softech/post-article/post-article.component';
import { PostInvoiceComponent } from './softech/post-invoice/post-invoice.component';
import { PostUsersComponent } from './softech/post-users/post-users.component';
import { PostPeopleComponent } from './softech/post-people/post-people.component';
import { GetUsersComponent } from './softech/get-users/get-users.component';

const routes: Routes = [
  {
  path: 'getPersona',
  component: GetPeopleComponent
  },
  {
  path: 'postPeople',
  component: PostPeopleComponent
  },
  {
    path: 'getUsers',
    component: GetUsersComponent
  },
  {
    path: 'postUsers',
    component: PostUsersComponent
  },
  {
    path: 'getInvoice',
    component: GetInvoiceComponent
  },
  {
    path: 'postInvoice',
    component: PostInvoiceComponent
  },
  {
    path: 'postArticle',
    component: PostArticleComponent
  },
  {
    path: 'getArticle',
    component: GetArticleComponent
  }
  ];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
