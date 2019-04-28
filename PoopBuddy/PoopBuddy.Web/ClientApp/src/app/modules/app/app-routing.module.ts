import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StartPageComponent } from '../start-page/start-page.component';
import { ListPoopingComponent } from '../list-pooping/list-pooping.component';

const routes: Routes = [
  {
    path: 'start',
    component: StartPageComponent
  },
  {
    path: 'list',
    component: ListPoopingComponent
  },
  {
    path: '',
    redirectTo: 'start',
    pathMatch: 'full'
  },
  {
    path: '**',
    redirectTo: 'start'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
