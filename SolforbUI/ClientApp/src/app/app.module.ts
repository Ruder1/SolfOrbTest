import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { ViewPageComponent } from './components/view-page/view-page.component';
import { CreateEditPageComponent } from './components/create-edit-page/create-edit-page.component';
import { NgSelectModule } from '@ng-select/ng-select';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    MainPageComponent,
    ViewPageComponent,
    CreateEditPageComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgSelectModule,
    ReactiveFormsModule,
    RouterModule.forRoot(
      [
      { path: '', component: MainPageComponent, pathMatch: 'full' },
      { path: 'mainPage', component: MainPageComponent},
      { path: 'createEditPage', component: CreateEditPageComponent},
      { path: 'viewPage', component: ViewPageComponent}
    ],
    {onSameUrlNavigation: 'reload'})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
