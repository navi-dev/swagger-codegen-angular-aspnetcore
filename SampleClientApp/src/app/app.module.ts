import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ApiModule, BASE_PATH } from 'sample-webapi';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ApiModule,
  ],
  providers: [{ provide: BASE_PATH, useValue: 'http://localhost:65099' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
