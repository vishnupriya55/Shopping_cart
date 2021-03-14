import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  ProductServiceProxy,
  UserDto,
  RoleDto,
  CreateProductInput,
  UpdateProductInput
} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent  extends AppComponentBase
  implements OnInit {
  saving = false;
  product = new UpdateProductInput();
  //roles: RoleDto[] = [];
  //checkedRolesMap: { [key: string]: boolean } = {};
  id: number;
  productDetails = new UpdateProductInput();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _productService: ProductServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.product=this.productDetails;

  }

  // setInitialRolesStatus(): void {
  //   _map(this.roles, (item) => {
  //     this.checkedRolesMap[item.normalizedName] = this.isRoleChecked(
  //       item.normalizedName
  //     );
  //   });
  // }

  // isRoleChecked(normalizedName: string): boolean {
  //   return _includes(this.user.roleNames, normalizedName);
  // }

  // onRoleChange(role: RoleDto, $event) {
  //   this.checkedRolesMap[role.normalizedName] = $event.target.checked;
  // }

  // getCheckedRoles(): string[] {
  //   const roles: string[] = [];
  //   _forEach(this.checkedRolesMap, function (value, key) {
  //     if (value) {
  //       roles.push(key);
  //     }
  //   });
  //   return roles;
  // }

  save(): void {
    this.saving = true;

    //this.user.roleNames = this.getCheckedRoles();
    console.log(this.product);
    console.log(this.productDetails);
    this._productService
      .updateProduct(this.product)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('UpdatedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}