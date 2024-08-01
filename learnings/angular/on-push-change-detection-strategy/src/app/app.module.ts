import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AOpComponent } from './a-op/a-op.component';
import { BOpComponent } from './b-op/b-op.component';

@NgModule({
  declarations: [
    AppComponent,
    AOpComponent,
    BOpComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
