#!/bin/bash


add_migration(){
read -p "Migration Name :" MIGRATION_NAME

  /usr/bin/dotnet ef migrations add $MIGRATION_NAME --project ControllRR.Infrastructure --output-dir Data/Migrations
}

update_migration(){
  /usr/bin/dotnet ef database update --project ControllRR.Infrastructure
}

build_run(){

/usr/bin/dotnet run --project ControllRR.Presentation

}


case "$1" in
'add')
  add_migration
  ;;
'update')
  update_migration
  ;;
'run')
  build_run
  ;;
  'drop')
  build_drop
  ;;
*)
  printf "usage tfc.show: add|update|create|drop|run"
esac
