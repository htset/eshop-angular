import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ItemsComponent } from './components/public/items/items.component';
import { ItemDetailsComponent } from './components/public/item-details/item-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FilterComponent } from './components/shared/filter/filter.component';
import { CartComponent } from './components/public/cart/cart.component';
import { LoginComponent } from './components/public/login/login.component';
import { AdminHomeComponent } from './components/admin/admin-home/admin-home.component';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { AdminUsersComponent } from './components/admin/admin-users/admin-users.component';
import { DeliveryAddressComponent } from './components/shared/delivery-address/delivery-address.component';
import { CheckoutComponent } from './components/public/checkout/checkout.component';

@NgModule({
  declarations: [
    AppComponent,
    ItemsComponent,
    ItemDetailsComponent,
    FilterComponent,
    CartComponent,
    LoginComponent,
    AdminHomeComponent,
    AdminUsersComponent,
    DeliveryAddressComponent,
    CheckoutComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgbModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor, multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
