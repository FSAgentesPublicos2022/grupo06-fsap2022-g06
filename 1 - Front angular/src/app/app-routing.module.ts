import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SobrenosotrosComponent } from './components/sobrenosotros/sobrenosotros.component';
import { ContactenosComponent } from './components/contactenos/contactenos.component';
import { BilleteraComponent } from './components/billetera/billetera.component';
import { CompraVentaComponent } from './components/compra-venta/compra-venta.component';
import { LoginComponent } from './components/login/login.component';

const app_routes: Routes = [
  { path: "home", component: HomeComponent },
  { path: "sobrenosotros", component: SobrenosotrosComponent },
  { path: "contactenos", component:  ContactenosComponent},
  { path: "billetera", component:  BilleteraComponent},
  { path: "compra-venta", component:  CompraVentaComponent},
  { path: "login", component: LoginComponent },
  { path: "", component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(app_routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }


