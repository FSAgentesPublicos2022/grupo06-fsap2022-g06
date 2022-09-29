import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { NavComponent } from './components/nav/nav.component';
import { PreloadComponent } from './components/preload/preload.component';
import { HomeComponent } from './components/home/home.component';
import { SobrenosotrosComponent } from './components/sobrenosotros/sobrenosotros.component';
import { HttpClientModule } from '@angular/common/http';
import { ContactenosComponent } from './components/contactenos/contactenos.component';
import { BilleteraComponent } from './components/billetera/billetera.component';
import { CompraVentaComponent } from './components/compra-venta/compra-venta.component';
import { LoginComponent } from './components/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    NavComponent,
    PreloadComponent,
    HomeComponent,
    SobrenosotrosComponent,
    ContactenosComponent,
    BilleteraComponent,
    CompraVentaComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
