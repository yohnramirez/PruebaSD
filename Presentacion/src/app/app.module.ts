import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './components/user/user.component';

import { NgIconsModule } from '@ng-icons/core';
import { bootstrapArrowDownShort, bootstrapArrowUpShort } from '@ng-icons/bootstrap-icons'

@NgModule({
  declarations: [
    AppComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgIconsModule.withIcons({ bootstrapArrowDownShort, bootstrapArrowUpShort }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
